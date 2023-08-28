import React from 'react';
import { Link, useNavigate } from "react-router-dom";
import axios from 'axios';
import Swal from 'sweetalert2';
import moment from 'moment';
import 'moment/locale/th'
import { API_URL } from '../../constants';

moment.locale('th')

const HomePage = () => {

    const navigate = useNavigate();



    const [dataCheckIn, setDataCheckIn] = React.useState([]);

    React.useEffect(() => {
        handleOnGetData();
    }, [])

    const handleOnCheckIn = (values) => {
        let userInfo = JSON.parse(localStorage.getItem("userInfo"));
        console.log("userInfo : ", userInfo)
        let request = {
            request: {
                id: userInfo.id,
            }
        }
        axios.post(API_URL + '/ManageUser/InsertCheckIn', request).then(function (response) {
            console.log("response : ", response);
            if (response.data.success === true) {
                Swal.fire({
                    title: 'สำเส็จ',
                    text: 'Check-in สำเร็จ',
                    icon: "success",
                    confirmButtonText: 'ปิด',
                }).then((result) => {
                    if (result.isConfirmed) {
                        handleOnGetData()
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

    const handleOnGetData = () => {
        let userInfo = JSON.parse(localStorage.getItem("userInfo"));
        console.log("userInfo : ", userInfo)
        let request = {
            id: userInfo.id,
        }
        axios.post(API_URL + '/ManageUser/SelectCheckInTimeStamp', { request: request }).then(function (response) {
            console.log("response : ", response);
            if (response.data.success === true) {
                let getDataCheckIn = response.data.responseObject.dataCheckIn;
                setDataCheckIn(getDataCheckIn);
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
        <div className="">
            <div className="col-12 text-center mb-3 mt-5">
                <button type="button" onClick={() => handleOnCheckIn()} className="btn btn-primary btn-lg">Check-in</button>
            </div>
            <div className="col-12">
                <h4>ประวัติการ Check-in</h4>
                <ul className="list-group">
                    {dataCheckIn.map((value, key) => {
                        return (
                            <li key={key} className="list-group-item d-flex justify-content-between align-items-center">
                                {moment(value.timeStamp).format("วันที่ D MMMM YYYY [เวลา] HH:mm:ss [น.]")}
                                <span>{moment(value.timeStamp).fromNow()}</span>
                            </li>
                        )
                    })}
                </ul>
            </div>
        </div>
    )
}

export default HomePage;