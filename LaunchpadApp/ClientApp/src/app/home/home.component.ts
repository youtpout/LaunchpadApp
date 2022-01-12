import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Observable, of } from 'rxjs';
import { CreatorService } from '../services/creator.service';
import { NotificationService } from '../services/notification.service';
import { WalletService } from '../services/wallet.service';
import { environment } from '../../environments/environment';
import { GlobalService } from '../services/global.service';
import { TokenService } from '../services/token.service';
import { PresaleService } from '../services/presale.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  account: any;
  tokens$: Observable<any> = of();
  fee = 0.1 * 10 ** 18;
  href: SafeUrl | null = null;
  encode: string = '';
  command: string = '';
  routerAddress: string = environment.pancakeRouter;
  tokenInCreation = false;

  form: FormGroup = new FormGroup({
    tokenAddress: new FormControl("", Validators.required),
    tokenAmount: new FormControl(0, Validators.required),
    tokenByBNB: new FormControl(0, Validators.required),
    amountMin: new FormControl(0, Validators.required),
    amountMax: new FormControl(0, Validators.required),
    softCap: new FormControl(0, Validators.required),
    hardCap: new FormControl(0, Validators.required)
  });


  constructor(private _presaleService: PresaleService,
    private _notification: NotificationService,
    private _walletService: WalletService,
    private _sanitizer: DomSanitizer,
    private _GlobalService: GlobalService) { }


  ngOnInit(): void {
    this._walletService.account$.subscribe(r => {
      if (r.length) {
        this.account = r[0];
      }
    });
  }

  createPresale() {
    this.form.markAllAsTouched();
    if (this.form.valid) {
      let values = this.form.value;
      let callCreate: Observable<string>;
      console.log(values);

      this._GlobalService.setLoading(true);
      this._notification.showWarning('Presale in creation, once you accepted transaction on Metamask, wait severals minutes and you can see it on Presale menu');
      this.tokenInCreation = true;
      this._presaleService.createPresale(values.tokenAddress, values.tokenAmount, values.tokenByBNB, values.amountMin, values.amountMax, values.softCap, values.hardCap).subscribe(
        (r) => {
          this._notification.showSuccess('Presale will appear after 2 min, you can see your presale on Presale page');
          this._GlobalService.setLoading(false);
          this.tokenInCreation = false;
        },
        (e) => {
          console.log(e);
          this._notification.showError(e.message);
          this._GlobalService.setLoading(false);
          this.tokenInCreation = false;
        }
      );
    }
    else {
      this._notification.showError('Fields required');
      this._GlobalService.setLoading(false);
      this.tokenInCreation = false;
    }
  }

}
