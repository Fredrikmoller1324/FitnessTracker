export class ExerciseModel{
    id: number;
    name:string;
    exerciseCategories: ExerciseCategoryModel[]
}

export class ExerciseCategoryModel{
    id:number;
    name:string;
}