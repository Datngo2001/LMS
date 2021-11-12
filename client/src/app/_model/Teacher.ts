import { Group } from "./Group";

export interface Teacher {
    id: number;
    firstname: string;
    lastname: string;
    gender: string;
    picture: string;
    cmnd: string;
    phone: string;
    birthday: string;
    address: string;
    created: string;
    lastActive: string;
    groups: Group[];
    userId: number;
    facultyId: number;
}