
import { Injectable } from '@angular/core';
import { environment} from './../environment/environment';
 
@Injectable()
export class EnvironmentUrlService {
 
  public urlAddress: string = environment.rootURL;
 
  constructor() { }
 
}