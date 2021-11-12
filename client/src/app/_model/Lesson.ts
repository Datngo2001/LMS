import { Content } from "./Content";

export interface Lesson {
    lId: number;
    order: number;
    name: string;
    groupId: number;
    contents: Content[];
}