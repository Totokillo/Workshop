import React from 'react';
import { Link, useNavigate } from "react-router-dom";
import { useFormik } from 'formik';
import * as Yup from 'yup';
import axios from 'axios';
import Swal from 'sweetalert2';
import { API_URL } from '../../constants';

const HomePage = () => {

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

    // console.log("formik : ", formik)
    return (
        <div className="">
         
        </div>
    )
}

export default HomePage;