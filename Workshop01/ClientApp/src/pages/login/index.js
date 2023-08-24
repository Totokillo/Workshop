import React from 'react';
import { Link } from "react-router-dom";

const LoginPage = () => {

    return (
        <div className="d-flex justify-content-center align-items-center vh-100 bg-secondary">
            <div className="col-6">
                <div className="card p-5">
                    <div className="card-body">
                        <form>
                            <div className="col-12 text-center">
                                <h2>Check-in System</h2>
                            </div>
                            <div className="mb-3">
                                <label htmlFor="exampleInputEmail1" className="form-label">Email address</label>
                                <input type="email" className="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="exampleInputPassword1" className="form-label">Password</label>
                                <input type="password" className="form-control" id="exampleInputPassword1" />
                            </div>

                            <div className="col-12 text-center mb-3 mt-5">
                                <button type="submit" className="btn btn-primary">Login</button>
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