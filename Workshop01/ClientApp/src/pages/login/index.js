import React from 'react';
import { Link, useNavigate } from "react-router-dom";
import { useFormik } from 'formik';
import * as Yup from 'yup';
import axios from 'axios';
import Swal from 'sweetalert2';
import { API_URL } from '../../constants';

const LoginPage = () => {

    const navigate = useNavigate();

    const SignupSchema = Yup.object().shape({
        email: Yup.string().email('Invalid Email').required('Email is Required'),
        password: Yup.string().required('Password is Required'),
    });

    const formik = useFormik({
        initialValues: {
            email: '',
            password: '',
        },
        validationSchema: SignupSchema,
        onSubmit: values => {
            handleOnSubmit(values)
        },
    });

    const handleOnSubmit = (values) => {
        let request = {
            request: {
                email: values.email,
                password: values.password,
            }
        }
        axios.post(API_URL + '/Permission/LoginPermission', request).then(function (response) {
            console.log("response : ", response);
            if (response.data.success === true) {
                localStorage.setItem("userInfo", JSON.stringify(response.data.responseObject))
                navigate('/home')
            }
            else {
                Swal.fire({
                    title: 'แจ้งเตือน',
                    text: response.data.message,
                    icon: 'warning',
                    confirmButtonText: 'ปิด'
                })
            }
        }).catch(function (error) {
            console.log("error : ", error);
            Swal.fire({
                title: 'แจ้งเตือน',
                text: error.message,
                icon: 'error',
                confirmButtonText: 'Ok'
            })
        });
    }

    return (
        <div className="d-flex justify-content-center align-items-center vh-100 bg-secondary">
            <div className="col-6">
                <div className="card p-5">
                    <div className="card-body">
                        <form onSubmit={formik.handleSubmit}>
                            <div className="col-12 text-center m-4">
                                <h1>ระบบ Check-in เข้าเรียน</h1>
                            </div>
                            <div className="col-12 text-center mb-4">
                                <h2>Login</h2>
                            </div>
                            <div className="mb-3">
                                <label htmlFor="email" className="form-label">อีเมล</label>
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
                            <div className="mb-3">
                                <label htmlFor="password" className="form-label">รหัสผ่าน</label>
                                <input
                                    id="password"
                                    name="password"
                                    type="password"
                                    onChange={formik.handleChange}
                                    value={formik.values.password}
                                    className="form-control"
                                />
                                {formik.touched.password && formik.errors.password && <small className="text-danger">{formik.errors.password}</small>}
                            </div>

                            <div className="col-12 text-center mb-3 mt-5">
                                <button type="submit" className="btn btn-primary">เข้าสู่ระบบ</button>
                            </div>
                            <div className="col-12 text-center">
                                <Link to="/register" className="">Register</Link>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default LoginPage;