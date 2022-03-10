import { Component, Inject, OnInit } from '@angular/core';
import { NB_WINDOW, NbMenuService } from '@nebular/theme';
import { filter, map } from 'rxjs/operators';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
    items = [
        { title: 'Profile' },
        { title: 'Logout', link:'/app/logout'},

    ];

  constructor(private nbMenuService: NbMenuService, @Inject(NB_WINDOW) private window) {

  }

    ngOnInit() {
        //this.nbMenuService.onItemClick()
        //    .pipe(
        //        filter(({ tag }) => tag === 'my-context-menu'),
        //        map(({ item: { title } }) => title),
        //    )
        //    .subscribe(title => this.window.alert(`${title} was clicked!`));
  }

}
