import axios from "axios";
import http from "../http-common";
import IPatientData from "../types/Patient";

const getAll = () => {
    return http.get<Array<IPatientData>>("/all");
};
const getById = (patientId: any) => {
    return http.get<IPatientData>(`/${patientId}`);
};
const create = (data: IPatientData) => {
    return http.post<IPatientData>("/add", data);
};
const update = (patientId: any, data: IPatientData) => {
    return http.patch<any>(`/edit/${patientId}`, data);
};
const remove = (patientId: any) => {
    return http.delete<any>(`/remove/${patientId}`);
};
const PatientService = {
    getAll,
    getById,
    create,
    update,
    remove
};
export default PatientService;