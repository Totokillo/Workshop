import React from 'react';
import { Link } from "react-router-dom";
import { useFormik } from 'formik';
import * as Yup from 'yup';

const RegisterPage = () => {

    const SignupSchema = Yup.object().shape({
        firstName: Yup.string().required('กรุณากรอก Fisrt Name'),
        lastName: Yup.string().required('กรุณากรอก Last Name'),
        email: Yup.string().email('Invalid email').required('Required'),
      });

    const formik = useFormik({
        initialValues: {
            firstName: '',
            lastName: '',
            email: '',
            birthDay: '',
            password: '',
            confirmPassword: '',
        },
        validationSchema:{SignupSchema},
        onSubmit: values => {
            alert(JSON.stringify(values, null, 2));
        },
    });

    return (
        <div className="d-flex justify-content-center align-items-center vh-100 bg-secondary">
            <div className="col-6">
                <div className="card p-5">
                    <div className="card-body">
                        <form onSubmit={formik.handleSubmit}>
                            <div className="col-12 text-center mb-4">
                                <h2>Register</h2>
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
                                </div>
                            </div>

                            <div className="row mb-2">
                                <div className="col-6">
                                    <label htmlFor="exampleInputEmail1" className="form-label">Email</label>
                                    <input
                                        id="email"
                                        name="email"
                                        type="text"
                                        onChange={formik.handleChange}
                                        value={formik.values.email}
                                        className="form-control"
                                    />
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
                                </div>
                            </div>

                            <div className="row mb-2">
                                <div className="col-6">
                                    <label htmlFor="birthDay" className="form-label">Password</label>
                                    <input
                                        id="password"
                                        name="password"
                                        type="password"
                                        onChange={formik.handleChange}
                                        value={formik.values.password}
                                        className="form-control"
                                    />
                                </div>
                                <div className="col-6">
                                    <label htmlFor="exampleInputPassword1" className="form-label">Confirm Password</label>
                                    <input
                                        id="confirmPassword"
                                        name="confirmPassword"
                                        type="password"
                                        onChange={formik.handleChange}
                                        value={formik.values.confirmPassword}
                                        className="form-control"
                                    />
                                </div>
                            </div>

                            <div className="col-12 text-center mb-3 mt-5">
                                <button type="submit" className="btn btn-primary">Register</button>
                            </div>
                            <div className="col-12 text-center">
                                <Link to="/login" className="">Login</Link>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default RegisterPage;