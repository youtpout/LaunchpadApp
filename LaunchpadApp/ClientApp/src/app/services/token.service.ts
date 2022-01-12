import { Injectable } from '@angular/core';
import { WalletService } from './wallet.service';
import { from, Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';
import launchpadAbi from '../abi/Launchpad.json';
import { ethers } from 'ethers';
import { TokenAddress } from '../models/token-address';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  _signer: any;

  private _creatorContract: any;
  private _storageContract: any;

  constructor(private _http: HttpClient) {
    const win: any = window;
    if (win.ethereum) {
      const webprovider = new ethers.providers.Web3Provider(win.ethereum, "any");
      this._signer = webprovider.getSigner();
      this._creatorContract = new ethers.Contract(
        environment.launchpadAddress,
        launchpadAbi,
        this._signer
      );
    }
  }

  private _presales: Subject<any[]> = new Subject();


  get presales(): Observable<any[]> {
    return this._presales.asObservable();
  }

  loadPresalesFromWS() {
    return this._http.get<any[]>("/api/blockchain").subscribe(r => this._presales.next(r));
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
