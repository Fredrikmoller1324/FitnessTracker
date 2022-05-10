import { ExerciseModel } from "./exercise.model";

export class WorkoutModel{
    name:string;
    date: Date;
    timeTaken:number;
    workoutexercices: WorkoutExercise[];

}

export class WorkoutExercise{
    exercise: ExerciseModel;
    reps:number;
    sets:number;
    weight:number;
}