import axios from 'axios'
import "reflect-metadata";
import { injectable } from 'inversify-props'
import ITasklistService from '@/services/ITasklistService'
import Task from '@/models/Task'

//@injectable()
export default class TaskService implements ITasklistService {
    private readonly API_URL: string = 'https://localhost:44388/api/task';
    public async getTasks(): Promise<Task[]> {
        const httpResponse = await axios.get<Task[]>(this.API_URL)
        return httpResponse.data;
    }

}