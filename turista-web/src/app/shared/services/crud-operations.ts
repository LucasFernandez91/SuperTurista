import { Observable } from 'rxjs';
import { GenericResponse } from '../model';

export interface CrudOperations<T, ID, saveModel, searchModel> {
    getAuthorizationHeader();
    save(t: saveModel): Observable<GenericResponse<T>>;
    update(id: ID, t: T): Observable<GenericResponse<T>>;
    get(id: ID): Observable<GenericResponse<T>>;
    // search(value:searchModel): Observable<GenericSearchResponse<T>>;
    delete(id: ID): Observable<any>;
}
