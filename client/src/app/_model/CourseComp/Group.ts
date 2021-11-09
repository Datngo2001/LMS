import { Lesson } from "./Lesson";

export class Group {
    gId: number;
    groupName: string;
    startDate: string;
    endDate: string;
    lecturer: string;
    lecturerProfileUrl: string;
    enrollslot: number;
    term: string;
    totalTime: string;
    totalslot: number;
    courseId: number;
    lessons: Lesson[];
}
