import React from "react";
import { Routes, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import AddPatient from "./components/AddPatient";
import ListPatients from "./components/ListPatients";
import UpdatePatient from "./components/UpdatePatient";

const App: React.FC = () => {
  return (
      <div>
        <nav className="navbar navbar-expand navbar-dark bg-dark">
          <a href="/" className="navbar-brand">
            Dentist
          </a>
          <div className="navbar-nav mr-auto">
            <li className="nav-item">
              <Link to={"/add"} className="nav-link">
                Add
              </Link>
            </li>
          </div>
        </nav>
        <div className="container mt-3">
          <Routes>
            <Route path="/" element={<ListPatients/>} />
            <Route path="/add" element={<AddPatient/>} />
            <Route path="/:patientId" element={<UpdatePatient/>} />
          </Routes>
        </div>
      </div>
  );
}
export default App;
