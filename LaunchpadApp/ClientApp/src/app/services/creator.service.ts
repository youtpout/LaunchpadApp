import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Injectable } from '@angular/core';
import { ethers, Signer, utils } from 'ethers';
import { tap, Subject, Observable, from } from 'rxjs';
import { environment } from '../../environments/environment';
import creatorAbi from '../abi/CreatorToken.json';
import storageAbi from '../abi/CreatorStorage.json';
import { TokenAddress } from '../models/token-address';
import { TokenCreated } from '../models/token-created';

@Injectable({
  providedIn: 'root',
})
export class CreatorService {
  private _signer?: Signer;
  private _creatorContract: any;
  private _storageContract: any;

  constructor() {
    const win: any = window;
    if (win.ethereum) {
      const webprovider = new ethers.providers.Web3Provider(win.ethereum, "any");
      this._signer = webprovider.getSigner();
      this._creatorContract = new ethers.Contract(
        environment.creatorAddress,
        creatorAbi,
        this._signer
      );

      this._storageContract = new ethers.Contract(
        environment.storageAddress,
        storageAbi,
        this._signer
      );

      // filter on contract created
      let filter = {
        address: environment.creatorAddress,
        topics: [utils.id('TokenCreated(string,string,uint256,address,address)')],
      };

      webprovider.on(filter, (log: TokenCreated, event) => {
        // permet de récupérer la liste des messages quand un nouveau message est ajouté
        console.log("token created", log, event);
      });
    }
  }
  private _messages: Subject<Message[]> = new Subject();

  // on utilisera cette observable afin de mettre à jour automatiquement
  // la liste des messages
  get messages(): Observable<Message[]> {
    return this._messages.asObservable();
  }

  // add simple token
  createToken(name: string, symbol: string, supply: number, nbDecimals: number, ownerTax: number, burnAmount: number, minimumSupply: number): Observable<string> {
    return from(this._createToken(name, symbol, supply, nbDecimals, ownerTax, burnAmount, minimumSupply)) as Observable<string>;
  }

  // add safemoon token
  createSafeMoonToken(name: string, symbol: string, uniswapRouter: string): Observable<string> {
    return from(this._createSafeMoon(name, symbol, uniswapRouter)) as Observable<string>;
  }

  contractsByCreator(address: string): Observable<TokenAddress[]> {
    return from(this._storageContract.contractsByCreator(address)) as Observable<TokenAddress[]>;
  }

  countContractsByCreator(address: string): Observable<number> {
    return from(this._storageContract.countContractsByCreator(address)) as Observable<number>;
  }

  getFee(): Observable<number> {
    return from(this._creatorContract.getFee()) as Observable<number>;
  }

  private async _createToken(name: string, symbol: string, supply: number, nbDecimals: number, ownerTax: number, burnAmount: number, minimumSupply: number): Promise<any> {
    let fee = await this._creatorContract.getFee();
    console.log(fee);
    let data = { value: fee };
    let _ownerTax = ownerTax * 100;
    let _burnTax = burnAmount * 100;
    let tx = await this._creatorContract.createToken(name, symbol, supply, nbDecimals, _ownerTax, _burnTax, minimumSupply, data);
    let txReceipt = await tx.wait();
    return txReceipt;
  }

  private async _createSafeMoon(name: string, symbol: string, routerAddress: string): Promise<any> {
    let fee = await this._creatorContract.getFee();
    let data = { value: fee };
    let tx = await this._creatorContract.createSafeMoonClone(name, symbol, routerAddress, data);
    let txReceipt = await tx.wait();
    return txReceipt;
  }
}
