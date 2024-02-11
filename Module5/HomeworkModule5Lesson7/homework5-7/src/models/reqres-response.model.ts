import { IResourceData } from "./resource.model";
import { ISupport } from "./support.model";
import { IUserData } from "./user.model";

export interface IReqresUserResponse {
    data: IUserData;
    support: ISupport;
}

export interface IReqresResourceResponse {
    data: IResourceData;
    support: ISupport;
}