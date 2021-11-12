import { Group } from "./Group";

export interface Course {
    cId: number;
    name: string;
    description: string;
    credits: number;
    groups: Group[];
    majorId: number;
}