import React, { useState, ChangeEvent } from "react";
import PatientDataService from "../services/PatientService";
import IPatientData from '../types/Patient';
import PatientService from "../services/PatientService";

const AddPatient: React.FC = () => {
    const initialPatientState = {
        patientId: null,
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

    const [patient, setPatient] = useState<IPatientData>(initialPatientState);
    const [submitted, setSubmitted] = useState<boolean>(false);
    const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.target;
        setPatient({ ...patient, [name]: value });
    };

    const savePatient = () => {
        var data = {
            patientId: patient.patientId,
            patientName: patient.patientName,
            patientSurname: patient.patientSurname,
            gender: patient.gender,
            pesel: patient.pesel,
            birthDate: patient.birthDate,
            phone: patient.phone,
            email: patient.email,
            city: patient.city,
            street: patient.street,
            houseNumber: patient.houseNumber
        };
        PatientService.create(data)
            .then((response: any) => {
                setPatient({
                    patientId: response.data.patientId,
                    patientName: response.data.patientName,
                    patientSurname: response.data.patientSurname,
                    gender: response.data.gender,
                    pesel: response.data.pesel,
                    birthDate: response.data.birthDate,
                    phone: response.data.phone,
                    email: response.data.email,
                    city: response.data.city,
                    street: response.data.street,
                    houseNumber: response.data.houseNumber
                });
                setSubmitted(true);
                console.log(response.data);
            })
            .catch((e: Error) => {
                console.log(e);
            });
    };
    const newPatient = () => {
        setPatient(initialPatientState);
        setSubmitted(false);
    };
    return ( <div className="submit-form">
            {submitted ? (
                <div>
                    <h4>You submitted successfully!</h4>
                    <button className="btn btn-success" onClick={newPatient}>
                        Add
                    </button>
                </div>
            ) : (
                <div>
                    <div className="form-group">
                        <label htmlFor="patientName">Name</label>
                        <input
                            type="text"
                            className="form-control"
                            id="patientName"
                            required
                            value={patient.patientName}
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
                            value={patient.patientSurname}
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
                            value={patient.gender}
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
                            value={patient.pesel}
                            onChange={handleInputChange}
                            name="pesel"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="birthDate">Birth date</label>
                        <input
                            type="text"
                            className="form-control"
                            id="birthDate"
                            required
                            value={patient.birthDate}
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
                            value={patient.phone}
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
                            value={patient.email}
                            onChange={handleInputChange}
                            name="email"
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="city">City</label>
                        <input
                            type="text"
                            className="form-control"
                            id="city"
                            required
                            value={patient.city}
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
                            value={patient.street}
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
                            value={patient.houseNumber}
                            onChange={handleInputChange}
                            name="houseNumber"
                        />
                    </div>
                    <button onClick={savePatient} className="btn btn-success">Submit</button>
                </div>
            )}
        </div>
    );
};
export default AddPatient;