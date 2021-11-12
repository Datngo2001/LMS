import { Course } from "./Course";

export interface Major {
    id: number;
    name: string;
    courses: Course[];
    facultyId: number;
}