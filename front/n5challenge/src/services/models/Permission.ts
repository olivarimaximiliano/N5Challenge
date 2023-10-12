import { PermissionType } from "./PermissionType";

export interface Permission {
  id: number;
  name: string;
  surname: string;
  Date: Date;
  permissionType: PermissionType;
}