import { Lesson } from "./Lesson";

export interface Group {
    gId: number;
    group_name: string;
    start_date: string;
    end_date: string;
    lecturer: string;
    enroll_slot: number;
    term: string;
    totalTime: string;
    total_slot: number;
    teacherId: number;
    courseId: number;
    lessons: Lesson[];
}