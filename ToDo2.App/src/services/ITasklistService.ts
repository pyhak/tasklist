import Task from '@/models/Task'

export default interface ITasklistService {
    getTasks(): Promise<Task[]>
}