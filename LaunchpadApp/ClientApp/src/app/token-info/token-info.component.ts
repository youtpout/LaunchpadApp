import { Component, Input, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { GlobalService } from '../services/global.service';
import { NotificationService } from '../services/notification.service';
import { PresaleService } from '../services/presale.service';
import { WalletService } from '../services/wallet.service';

@Component({
  selector: 'app-token-info',
  templateUrl: './token-info.component.html',
  styleUrls: ['./token-info.component.scss'],
})
export class TokenInfoComponent implements OnInit {
  @Input() token: any;

  constructor(private _presaleService: PresaleService,
    private _notification: NotificationService,
    private _globalService: GlobalService,
    private _walletService: WalletService) { }

  ngOnInit(): void { }

  info() {
    window.open(
      environment.explorer + this.token?.tokenAddress,
      '_blank'
    );
  }

  get isOwner() {
    return this._walletService.accountConnected.toLowerCase() == this.token.owner.toLowerCase();
  }

  launch() {
    if (!this.isOwner) {
      this._notification.showError("Only owner can launch");
      return;
    }
    this._globalService.setLoading(true);
    this._presaleService.launch(this.token.id).subscribe(
      (r) => {
        this._notification.showSuccess('Presale update will appear after 2 min');
        this._globalService.setLoading(false);
      },
      (e) => {
        console.log(e);
        this._notification.showError(e.message);
        this._globalService.setLoading(false);
      }
    );
  }
}
