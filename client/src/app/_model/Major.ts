import { Course } from "./Course";

export interface Major {
    mId: number;
    name: string;
    courses: Course[];
    facultyId: number;
}