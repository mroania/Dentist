import React, { useState, useEffect, ChangeEvent } from "react";
import PatientDataService from "../services/PatientService";
import IPatientData from '../types/Patient';
import {Link} from "react-router-dom";

const PatientsList: React.FC = () => {
    const [patients, setPatients] = useState<Array<IPatientData>>([]);
    const [currentPatient, setCurrentPatient] = useState<IPatientData | null>(null);
    const [currentIndex, setCurrentIndex] = useState<number>(-1);

    useEffect(() => {
        retrievePatients();
    }, []);

    const retrievePatients = () => {
        PatientDataService.getAll()
            .then((response: any) => {
                setPatients(response.data);
                console.log(response.data);
            })
            .catch((e: Error) => {
                console.log(e);
            });
    };
    const refreshList = () => {
        retrievePatients();
        setCurrentPatient(null);
        setCurrentIndex(-1);
    };
    const setActivePatient = (Patient: IPatientData, index: number) => {
        setCurrentPatient(Patient);
        setCurrentIndex(index);
    };

    return (
        <div className="list row">
            <div className="col-md-6">
                <h4>Patients List</h4>
                <ul className="list-group">
                    {patients &&
                        patients.map((patient, index) => (
                            <li
                                className={
                                    "list-group-item " + (index === currentIndex ? "active" : "")
                                }
                                onClick={() => setActivePatient(patient, index)}
                                key={index}
                            >
                                {patient.patientName + " " + patient.patientSurname}
                            </li>
                        ))}
                </ul>
            </div>
            <div className="col-md-6">
                {currentPatient ? (
                    <div>
                        <h4>Patient</h4>
                        <div>
                            <label>
                                <strong>ID:</strong>
                            </label>{" "}
                            {currentPatient.patientId}
                        </div>
                        <div>
                            <label>
                                <strong>Name:</strong>
                            </label>{" "}
                            {currentPatient.patientName}
                        </div>
                        <div>
                            <label>
                                <strong>Surname:</strong>
                            </label>{" "}
                            {currentPatient.patientSurname}
                        </div>
                        <div>
                            <label>
                                <strong>Gender:</strong>
                            </label>{" "}
                            {currentPatient.gender}
                        </div>
                        <div>
                            <label>
                                <strong>Pesel:</strong>
                            </label>{" "}
                            {currentPatient.pesel}
                        </div>
                        <div>
                            <label>
                                <strong>Brith date:</strong>
                            </label>{" "}
                            {currentPatient.birthDate}
                        </div>
                        <div>
                            <label>
                                <strong>Phone:</strong>
                            </label>{" "}
                            {currentPatient.phone}
                        </div>
                        <div>
                            <label>
                                <strong>Email:</strong>
                            </label>{" "}
                            {currentPatient.email}
                        </div>
                        <div>
                            <label>
                                <strong>City:</strong>
                            </label>{" "}
                            {currentPatient.city}
                        </div>
                        <div>
                            <label>
                                <strong>Street:</strong>
                            </label>{" "}
                            {currentPatient.street}
                        </div>
                        <div>
                            <label>
                                <strong>House number:</strong>
                            </label>{" "}
                            {currentPatient.houseNumber}
                        </div>
                        <Link
                            to={"/" + currentPatient.patientId}
                            className="badge badge-warning"
                        >
                            Edit
                        </Link>
                    </div>
                ) : (
                    <div>
                        <br />
                        <p>Please click on a Patient...</p>
                    </div>
                )}
            </div>
        </div>
    );
};
export default PatientsList;