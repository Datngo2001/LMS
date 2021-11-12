import { Major } from "./Major";
import { Teacher } from "./Teacher";

export interface Faculty {
    id: number;
    name: string;
    majors: Major[];
    teachers: Teacher[];
}