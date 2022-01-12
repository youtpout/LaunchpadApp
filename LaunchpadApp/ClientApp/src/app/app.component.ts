import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreatorService } from './services/creator.service';
import { GlobalService } from './services/global.service';
import { WalletService } from './services/wallet.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Create Token';
  account: any;
  loading = false;
  isProd = environment.production;
  isMenuOpen = false;

  constructor(private _walletService: WalletService, private _creatorService: CreatorService, private _GlobalService: GlobalService) {
    this._walletService.account$.subscribe(r => this.account = r);
    this._GlobalService.loading$.subscribe(r => this.loading = r);
  }

  connect(): void {
    this._walletService.connect().subscribe();
  }
}
