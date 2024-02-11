import { IResourceData } from "./resource.model";
import { ISupport } from "./support.model";
import { IUserData } from "./user.model";

export interface IReqresUsersResponse {
    page: number;
    per_page: number;
    total: number;
    total_pages: number;
    data: IUserData[];
    support: ISupport;
}

export interface IReqresResourcesResponse {
    page: number;
    per_page: number;
    total: number;
    total_pages: number;
    data: IResourceData[];
    support: ISupport;
}