import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { LoginService } from '../services/login.service';

export const adminGuard: CanActivateFn = (route, state) => {
  const loginService = inject(LoginService);

  console.log('Checking admin access, Current User:', loginService.currentUser); // הוסף כאן

  if (loginService.isManager())
    return true;
  return false;
};
