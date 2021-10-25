import { Lesson } from "./Lesson";

export class Group {
    Group_name: string;
    Start_date: string;
    End_date: string;
    Lecturer: string;
    LecturerProfileUrl: string;
    Enroll_slot: number;
    Term: string;
    TotalTime: string;
    Total_slot: number;
    CourseId: number;
    Lessons: Lesson[];
}
