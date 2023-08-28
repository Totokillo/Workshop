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
        firstName: Yup.string().required('กรุณากรอกชื่อ'),
        lastName: Yup.string().required('กรุณากรอกนามสกุล'),
        email: Yup.string().email('อีเมลไม่ถูกต้อง').required('กรุณากรอกอีเมล'),
        birthDay: Yup.string().required('กรุณาเลือกวันเดือนปีเกิด(ค.ศ.)'),
    });

    const formik = useFormik({
        initialValues: {
            id: '',
            firstName: '',
            lastName: '',
            email: '',
            birthDay: '',
        },
        validationSchema: SignupSchema,
        onSubmit: values => {
            handleOnSubmit(values)
        },
    });

    React.useEffect(() => {
        handleOnGetData();
    }, [])

    const handleOnSubmit = (values) => {
        let request = {
            request: {
                id: values.id,
                firstName: values.firstName,
                lastName: values.lastName,
                email: values.email,
                birthDay: values.birthDay,
            }
        }
        axios.post(API_URL + '/ManageUser/UpdateManageUser', request).then(function (response) {
            console.log("response : ", response);
            if (response.data.success === true) {
                Swal.fire({
                    title: 'สำเร็จ',
                    text: 'บันทึกการแก้ไขสำเร็จ',
                    icon: "success",
                    confirmButtonText: 'ปิด',
                }).then((result) => {
                    if (result.isConfirmed) {
                        handleOnGetData();
                    }
                })
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
                confirmButtonText: 'ปิด'
            })
        });
    }

    const handleOnCancel = () => {
        let userInfo = JSON.parse(localStorage.getItem("userInfo"));
        console.log("userInfo : ", userInfo)
        let request = {
            request: {
                id: userInfo.id,
            }
        }
        Swal.fire({
            title: 'ยืนยัน',
            text: 'ยืนยันยกเลิกสมาชิก',
            showCancelButton: true,
            cancelButtonText: 'ปิด',
            confirmButtonText: 'ยืนยัน',
        }).then((result) => {
            if (result.isConfirmed) {
                axios.post(API_URL + '/ManageUser/DeleteManageUser', request).then(function (response) {
                    console.log("response : ", response);
                    if (response.data.success === true) {
                        Swal.fire({
                            title: 'สำเร็จ',
                            text: 'ยกเลิกสมาชิกสำเร็จ',
                            icon: "success",
                            confirmButtonText: 'ปิด',
                        }).then((result) => {
                            if (result.isConfirmed) {
                                navigate('/')
                            }
                        })
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
                        confirmButtonText: 'ปิด'
                    })
                });
            }
        })
    }

    const handleOnGetData = () => {
        let userInfo = JSON.parse(localStorage.getItem("userInfo"));
        console.log("userInfo : ", userInfo)
        let request = {
            request: {
                id: userInfo.id,
            }
        }
        axios.post(API_URL + '/ManageUser/SelectManageUser', request).then(function (response) {
            console.log("response : ", response);
            if (response.data.success === true) {
                let responseObject = response.data.responseObject;
                formik.setFieldValue("id", responseObject.id)
                formik.setFieldValue("firstName", responseObject.firstName)
                formik.setFieldValue("lastName", responseObject.lastName)
                formik.setFieldValue("email", responseObject.email)
                formik.setFieldValue("birthDay", responseObject.birthDay)
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
                confirmButtonText: 'ปิด'
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
                            <label htmlFor="firstName" className="form-label">ชื่อ</label>
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
                            <label htmlFor="lastName" className="form-label">นามสกุล</label>
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
                        <div className="col-6">
                            <label htmlFor="birthDay" className="form-label">วันเดือนปีเกิด(ค.ศ.)</label>
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

                    <div className="col-12 mb-3 mt-5 d-flex gap-2 justify-content-center">
                        <button type="submit" className="btn btn-primary">บันทึกการแก้ไข</button>
                        <button type="button" onClick={() => handleOnCancel()} className="btn btn-danger">ยกเลิกสมาชิก</button>
                    </div>
                </form>
                {/* </div>
                </div> */}
            </div>
        </div>
    )
}

export default ProfilePage;