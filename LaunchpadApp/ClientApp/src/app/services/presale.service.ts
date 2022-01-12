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
export class PresaleService {
  _signer: any;

  private _presaleContract: any;
  private _storageContract: any;
  private accountConnect:string="";

  constructor(private _http: HttpClient, private _walletService: WalletService) {
    this.init();
    this._walletService.account$.subscribe(r => {
      this.accountConnect = r;
      this.init()
    });
  }

  private init() {
    const win: any = window;
    if (win.ethereum) {
      const webprovider = new ethers.providers.Web3Provider(win.ethereum, "any");
      this._signer = webprovider.getSigner();
      this._presaleContract = new ethers.Contract(
        environment.launchpadAddress,
        launchpadAbi,
        this._signer
      );
    }
  }

  private _presales$: Subject<any[]> = new Subject();


  get presales$(): Observable<any[]> {
    return this._presales$.asObservable();
  }

  loadPresalesFromWS() {
    return this._http.get<any[]>("/api/blockchain").subscribe(r => this._presales$.next(r));
  }

  // add presale
  createPresale(tokenAddress: string, tokenAmount: number, tokenByBNB: number, amountMin: number, amountMax: number, softCap: number, hardCap: number): Observable<string> {
    return from(this._createPresale(tokenAddress, tokenAmount, tokenByBNB, amountMin, amountMax, softCap, hardCap)) as Observable<string>;
  }

  private async _createPresale(tokenAddress: string, tokenAmount: number, tokenByBNB: number, amountMin: number, amountMax: number, softCap: number, hardCap: number): Promise<any> {
    if (!this._presaleContract) {
      throw new Error("Not connected to web3");
    }
    let tx = await this._presaleContract.createPresale(tokenAddress, tokenAmount, tokenByBNB, amountMin, amountMax, softCap, hardCap);
    let txReceipt = await tx.wait();
    return txReceipt;
  }

  launch(presaleId: number): Observable<string> {
    return from(this._launch(presaleId)) as Observable<string>;
  }

  private async _launch(presaleId: number): Promise<any> {
    let end = Date.now() / 1000;
    // 7 days to end 
    end += 60 * 60 * 24 * 7;
    if (!this._presaleContract) {
      throw new Error("Not connected to web3");
    }
    console.log(presaleId);
    console.log(end.toFixed(0));
    let tx = await this._presaleContract.launch(presaleId, end.toFixed(0));
    let txReceipt = await tx.wait();
    return txReceipt;
  }

}
