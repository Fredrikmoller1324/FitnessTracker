import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpParams,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { exhaustMap, take, tap } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
  constructor(private authService:AuthService ,private router: Router) {}


  intercept(req: HttpRequest<any>, next: HttpHandler) {
    return this.authService.user.pipe(
      take(1),
      exhaustMap(user => {
        if (!user) {
          return next.handle(req);
        }
        const modifiedReq = req.clone({
          params: new HttpParams().set('auth', user.token)
        });
        return next.handle(modifiedReq);
      })
    );
  }
  // intercept(
  //   req: HttpRequest<any>,
  //   next: HttpHandler
  // ): Observable<HttpEvent<any>> {
  //   if (localStorage.getItem('token') != null) {
  //     const clonedReq = req.clone({
  //       headers: req.headers.set(
  //         'Authorization',
  //         'Bearer ' + localStorage.getItem('token')
  //       ),
  //     });
  //     return next.handle(clonedReq).pipe(
  //       tap(
  //         (succ) => {},
  //         (err) => {
  //           // logsout user if request returns 401 (unauthorized) like what happens if token has expiered
  //           if (err.status == 401) {
  //             localStorage.removeItem('token');
  //             this.router.navigateByUrl('/login');
  //           }
  //         }
  //       )
  //     );
  //   } else return next.handle(req.clone());
  // }
}
