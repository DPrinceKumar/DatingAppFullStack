import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { catchError, Observable } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorsInterceptor implements HttpInterceptor {
  constructor(private route: Router, private toasterService: ToastrService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((e: HttpErrorResponse) => {
        if (e) {
          switch (e.status) {
            case 400:
              if (e.error.errors) {
                const modelStateError = [];
                for (const key in e.error.errors) {
                  if (e.error.errors[key]) {
                    modelStateError.push(e.error.errors[key]);
                  }
                }
                throw modelStateError.flat();
              } else {
                this.toasterService.error(e.error,e.status.toString());
              }
              break;

            case 401:
              this.toasterService.error("Unauthorized",e.status.toString());
              break;

            case 404:
              this.route.navigateByUrl('/not-found');
              break;
            case 500:
              const navigationExtras:NavigationExtras={state: {error: e.error}};
              this.route.navigateByUrl('/server-error', navigationExtras);
              break;

            default:this.toasterService.error('Something went wrong');
            console.log(e);
              break;
          }
        }

        throw e;
      })
    );
  }
}
