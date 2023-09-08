import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
    }

    async populateWeatherData() {

        const requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ request: {} })
        };
        const response = await fetch('https://localhost:44358/Student/GetStudentInfo', requestOptions).then(response => response.json()).then(response => {
             console.log(response);
            const data =  response.responseObject?.dataStudent;
            this.setState({ forecasts: data, loading: false })
        }
        );
      

    }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
                    <th>studentId</th>
                    <th>studentName</th>
          </tr>
        </thead>
        <tbody>
                {forecasts?.map(forecast => {
                    return (
                        <tr key={forecast.studentId}>
                        <td>{forecast.studentId}</td>
                       <td>{forecast.studentName}</td>
                        </tr>
                    )}
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

      console.log(FetchData);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }


   
}
