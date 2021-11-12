import { Content } from "./Content";

export interface Lesson {
    id: number;
    order: number;
    name: string;
    groupId: number;
    contents: Content[];
}