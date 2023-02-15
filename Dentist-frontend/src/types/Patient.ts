export default interface IPatientData
{
    patientId: number | null,
    patientName: string,
    patientSurname: string,
    gender: Gender,
    pesel: string,
    birthDate: any,
    phone: string,
    email: string,
    city: string,
    street: string,
    houseNumber: string
}

enum Gender
{
    Male = 0,
    Female = 1
}