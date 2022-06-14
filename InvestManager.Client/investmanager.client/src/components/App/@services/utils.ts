import {ApiException} from "../../../client/client";
import swal from 'sweetalert';

export const executeWithExceptionHandling = async (execute: () => void) => {
    try{
        await execute();
    }
    catch (exception)
    {
        if(exception instanceof ApiException){
            swal("Ошибка!", `${JSON.parse(exception.response)}`, "error");
        }
    }
}