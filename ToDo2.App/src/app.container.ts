import { container } from 'inversify-props'
import ITasklistService from '@/services/ITasklistService'
import TasklistService from '@/services/TasklistService'

export default function buildDependencyContainer(): void {
    //container.addTransient<ITasklistService>(TasklistService)
}