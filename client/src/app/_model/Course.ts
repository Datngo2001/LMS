import { Lesson } from "./Lesson";

export interface Course {
    id: number
    name: string
    description?: string
    teacherName: string
    imageUrl?: string
    lessons?: Lesson[]
}