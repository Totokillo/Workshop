import React from 'react';
import { useNavigate } from "react-router-dom";
import { useFormik } from 'formik';
import * as Yup from 'yup';
import axios from 'axios';
import Swal from 'sweetalert2';
import { API_URL } from '../../constants';

const ProfilePage = () => {

    const navigate = useNavigate();

    

    const SignupSchema = Yup.object().shape({
        firstName: Yup.string().required('Fisrt Name is Required'),
        lastName: Yup.string().required('Last Name is Required'),
        email: Yup.string().email('Invalid Email').required('Email is Required'),
        birthDay: Yup.string().required('Birth Day is Required'),
        password: Yup.string().required('Password is Required'),
    });

    const formik = useFormik({
        initialValues: {
            firstName: '',
            lastName: '',
            email: '',
            birthDay: '',
            password: '',
        },
        validationSchema: SignupSchema,
        onSubmit: values => {
            handleOnSubmit(values)
        },
    });

    const handleOnSubmit = (values) => {
        let request = {
            firstName: values.firstName,
            lastName: values.lastName,
            email: values.email,
            birthDay: values.birthDay,
            password: values.password,
        }
        axios.post(API_URL + '/ManageUser/InsertManageUser', request).then(function (response) {
            console.log("response : ", response);
            if (response.data.success === true) {
                Swal.fire({
                    title: 'Success',
                    icon: "success",
                    confirmButtonText: 'Ok',
                }).then((result) => {
                    if (result.isConfirmed) {
                        navigate('/')
                    }
                })
            }
            else {
                Swal.fire({
                    title: 'Warning!',
                    text: response.message,
                    icon: 'warning',
                    confirmButtonText: 'Ok'
                })
            }
        }).catch(function (error) {
            console.log("error : ", error);
            Swal.fire({
                title: 'Error!',
                text: error.message,
                icon: 'error',
                confirmButtonText: 'Ok'
            })
        });
    }

    const handleOnGetData = () => {
        let request = {
            // firstName: values.firstName,
            // lastName: values.lastName,
            // email: values.email,
            // birthDay: values.birthDay,
            // password: values.password,
        }
        axios.post(API_URL + '/ManageUser/InsertManageUser', request).then(function (response) {
            console.log("response : ", response);
            if (response.data.success === true) {
                Swal.fire({
                    title: 'Success',
                    icon: "success",
                    confirmButtonText: 'Ok',
                }).then((result) => {
                    if (result.isConfirmed) {
                        navigate('/')
                    }
                })
            }
            else {
                Swal.fire({
                    title: 'Warning!',
                    text: response.message,
                    icon: 'warning',
                    confirmButtonText: 'Ok'
                })
            }
        }).catch(function (error) {
            console.log("error : ", error);
            Swal.fire({
                title: 'Error!',
                text: error.message,
                icon: 'error',
                confirmButtonText: 'Ok'
            })
        });
    }

    // console.log("formik : ", formik)
    return (
        <div className="d-flex justify-content-center align-items-center">
            <div className="col-6">
                {/* <div className="card p-5">
                    <div className="card-body"> */}
                        <form onSubmit={formik.handleSubmit}>
                            <div className="col-12 text-center mb-4">
                                <h2>Profile</h2>
                            </div>

                            <div className="row mb-2">
                                <div className="col-6">
                                    <label htmlFor="firstName" className="form-label">Fisrt Name</label>
                                    <input
                                        id="firstName"
                                        name="firstName"
                                        type="text"
                                        onChange={formik.handleChange}
                                        value={formik.values.firstName}
                                        className="form-control"
                                    />
                                    {formik.touched.firstName && formik.errors.firstName && <small className="text-danger">{formik.errors.firstName}</small>}
                                </div>
                                <div className="col-6">
                                    <label htmlFor="lastName" className="form-label">Last Name</label>
                                    <input
                                        id="lastName"
                                        name="lastName"
                                        type="text"
                                        onChange={formik.handleChange}
                                        value={formik.values.lastName}
                                        className="form-control"
                                    />
                                    {formik.touched.lastName && formik.errors.lastName && <small className="text-danger">{formik.errors.lastName}</small>}
                                </div>
                            </div>

                            <div className="row mb-2">
                                <div className="col-6">
                                    <label htmlFor="email" className="form-label">Email</label>
                                    <input
                                        id="email"
                                        name="email"
                                        type="text"
                                        onChange={formik.handleChange}
                                        value={formik.values.email}
                                        className="form-control"
                                    />
                                    {formik.touched.email && formik.errors.email && <small className="text-danger">{formik.errors.email}</small>}
                                </div>
                                <div className="col-6">
                                    <label htmlFor="birthDay" className="form-label">Birth Day</label>
                                    <input
                                        id="birthDay"
                                        name="birthDay"
                                        type="date"
                                        onChange={formik.handleChange}
                                        value={formik.values.birthDay}
                                        className="form-control"
                                    />
                                    {formik.touched.birthDay && formik.errors.birthDay && <small className="text-danger">{formik.errors.birthDay}</small>}
                                </div>
                            </div>

                            <div className="col-12 text-center mb-3 mt-5">
                                <button type="submit" className="btn btn-primary">Save</button>
                            </div>
                        </form>
                    {/* </div>
                </div> */}
            </div>
        </div>
    )
}

export default ProfilePage;