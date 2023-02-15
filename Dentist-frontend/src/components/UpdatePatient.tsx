import React, { useState, useEffect, ChangeEvent } from "react";
import { useParams, useNavigate } from 'react-router-dom';
import PatientDataService from "../services/PatientService";
import IPatientData from "../types/Patient";

const Patient: React.FC = () => {
    const { patientId }= useParams();
    let navigate = useNavigate();
    const initialPatientState = {
        patientId: 0,
        patientName: "",
        patientSurname: "",
        gender: 0,
        pesel: "",
        birthDate: "",
        phone: "",
        email: "",
        city: "",
        street: "",
        houseNumber: ""
    };
    
    const [currentPatient, setCurrentPatient] = useState<IPatientData>(initialPatientState);
    const [message, setMessage] = useState<string>("");
    const getPatient = (patientId: string) => {
        PatientDataService.getById(patientId)
            .then((response: any) => {
                setCurrentPatient(response.data);
                console.log(response.data);
            })
            .catch((e: Error) => {
                console.log(e);
            });
    };
    useEffect(() => {
        if (patientId)
            getPatient(patientId);
    }, [patientId]);

    const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.target;
        setCurrentPatient({ ...currentPatient, [name]: value });
    };

    const updatePatient = () => {
        console.log(currentPatient.patientName);
    PatientDataService.update(currentPatient.patientId, currentPatient)
        .then((response: any) => {
            console.log(response.data);
            navigate("/");
            setMessage("The patient was updated successfully!");
        })
        .catch((e: Error) => {
        console.log(e);
        });
    };


    const deletePatient = () => {
        PatientDataService.remove(currentPatient.patientId)
            .then((response: any) => {
                console.log(response.data);
                navigate("/");
            })
            .catch((e: Error) => {
                console.log(e);
            });
            
    };
    return (
        <div>
            {currentPatient ? (
                <div className="edit-form">
                    <h4>Patient</h4>
                    <form>
                    <div className="form-group">
                        <label htmlFor="patientName">Name</label>
                        <input
                            type="text"
                            className="form-control"
                            id="patientName"
                            required
                            value={currentPatient.patientName}
                            onChange={handleInputChange}
                            name="patientName"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="patientSurname">Surname</label>
                        <input
                            type="text"
                            className="form-control"
                            id="patientSurname"
                            required
                            value={currentPatient.patientSurname}
                            onChange={handleInputChange}
                            name="patientSurname"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="gender">Gender</label>
                        <input
                            type="text"
                            className="form-control"
                            id="gender"
                            required
                            value={currentPatient.gender}
                            onChange={handleInputChange}
                            name="gender"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="pesel">Pesel</label>
                        <input
                            type="text"
                            className="form-control"
                            id="pesel"
                            required
                            value={currentPatient.pesel}
                            onChange={handleInputChange}
                            name="pesel"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="birthDate">Birth date</label>
                        <input
                            type="text"
                            className="form-control"
                            id="pbirthDate"
                            required
                            value={currentPatient.birthDate}
                            onChange={handleInputChange}
                            name="birthDate"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="phone">Phone number</label>
                        <input
                            type="text"
                            className="form-control"
                            id="phone"
                            required
                            value={currentPatient.phone}
                            onChange={handleInputChange}
                            name="phone"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="email">E-mail</label>
                        <input
                            type="email"
                            className="form-control"
                            id="email"
                            required
                            value={currentPatient.email}
                            onChange={handleInputChange}
                            name="email"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="city">City</label>
                        <input
                            type="text"
                            className="form-control"
                            id="pcity"
                            required
                            value={currentPatient.city}
                            onChange={handleInputChange}
                            name="city"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="street">Street</label>
                        <input
                            type="text"
                            className="form-control"
                            id="street"
                            required
                            value={currentPatient.street}
                            onChange={handleInputChange}
                            name="street"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="houseNumber">House number</label>
                        <input
                            type="text"
                            className="form-control"
                            id="houseNumber"
                            required
                            value={currentPatient.houseNumber}
                            onChange={handleInputChange}
                            name="houseNumber"
                        />
                    </div>
                    </form>
                    <button 
                        className="badge badge-danger mr-2" 
                        onClick={deletePatient}
                        >
                            Delete
                    </button>
                    <button
                        type="submit"
                        className="badge badge-success"
                        onClick={updatePatient}
                    >
                        Update
                    </button>
                    <p>{message}</p>
                </div>
            ) : (
                <div>
                    <br />
                    <p>Please click on a Patient...</p>
                </div>
            )}
        </div>
    );
};
export default Patient;