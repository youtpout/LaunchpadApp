import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { CreatorService } from '../services/creator.service';
import { GlobalService } from '../services/global.service';
import { NotificationService } from '../services/notification.service';
import { PresaleService } from '../services/presale.service';
import { TokenService } from '../services/token.service';
import { WalletService } from '../services/wallet.service';

@Component({
  selector: 'app-tokens',
  templateUrl: './tokens.component.html',
  styleUrls: ['./tokens.component.scss'],
})
export class TokensComponent implements OnInit {
  account: string = '';
  tokens: any[] = [];

  constructor(
    private _walletService: WalletService,
    private _creatorService: CreatorService,
    private _tokenService: TokenService,
    private _presaleService: PresaleService,
    private _notification: NotificationService,
    private _globalService: GlobalService
  ) { }

  ngOnInit(): void {
    this._presaleService.presales$.subscribe(
      (r) => {
        console.log("presales", r);
        this.tokens = r;
      },
      (e) => console.log(e)
    );

    this._presaleService.loadPresalesFromWS();
    setInterval(() => {
      // call ws every 30 sec
      this._presaleService.loadPresalesFromWS();
    }, 30000);

  }

  //getTokens() {
  //  this._globalService.setLoading(true);
  //  this._creatorService.contractsByCreator(this.account).subscribe(
  //    (r) => {
  //      this._globalService.setLoading(false);
  //      if (r?.length) {
  //        for (let index = 0; index < r.length; index++) {
  //          const element = r[index];
  //          this._globalService.setLoading(true);
  //          this._tokenService
  //            .getTokenInfo(element)
  //            .subscribe((r) => {
  //              this.tokens.push(r);
  //              this._globalService.setLoading(false);
  //            },
  //              (e) => {
  //                console.log(e);
  //                this._globalService.setLoading(false);
  //              });
  //        }
  //      }
  //    },
  //    (e) => {
  //      console.log(e);
  //      this._globalService.setLoading(false);
  //    }
  //  );
  //}
}
