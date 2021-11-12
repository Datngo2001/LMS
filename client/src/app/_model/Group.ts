import { Lesson } from "./Lesson";

export interface Group {
    id: number;
    groupName: string;
    startDate: string;
    endDate: string;
    lecturer: string;
    enrollSlot: number;
    term: string;
    totalTime: string;
    totalSlot: number;
    teacherId: number;
    courseId: number;
    lessons: Lesson[];
}