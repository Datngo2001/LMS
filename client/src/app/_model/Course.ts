import { Group } from "./Group";

export interface Course {
    id: number;
    name: string;
    description: string;
    credits: number;
    groups: Group[];
    majorId: number;
}