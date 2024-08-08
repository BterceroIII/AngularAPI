export interface ApiResponse<T>{
    message: string;
    $values: T;
}