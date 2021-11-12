import { Major } from "./Major";
import { Teacher } from "./Teacher";

export interface Faculty {
    fId: number;
    name: string;
    majors: Major[];
    teachers: Teacher[];
}