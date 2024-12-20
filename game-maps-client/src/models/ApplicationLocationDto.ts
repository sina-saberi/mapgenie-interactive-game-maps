import { ILocationDto } from "../services/nswag";

export interface ApplicationLocationDto extends ILocationDto {
    iconBase64?: string;
    icon?: string;
    categoryId: number;
}