import React, { Component } from 'react';
/*import axios from 'axios';*/
import './Validate.css';
import axios from 'axios';

export class Validate extends Component {
    //api/validate/validate
    state = {
        Name: '',
        Address1: '',
        Address2: '',
        City: '',
        State: '',
        Zip5: '',
        Zip4: ''
    }

    handleChange = (event) => {
        this.setState({ [event.target.name]: event.target.value })
    }

    handleSubmit = event => {
        event.preventDefault();
        console.log(this.state)
        /*const address = {
            Name: this.state.Name,
            Address1: this.state.Address1,
            Address2: this.state.Address2,
            City : this.state.City,
            State :  this.state.State,
            Zip5 : this.state.Zip5,
            Zip4 : this.state.Zip4
        };*/
        axios.post('/api/validate/validate', this.state)
            .then(response => {
                console.log(response);
            })
            .catch(error => {
                console.log(error)
            })

    };


    render() {
        const { Name, Address1, Address2, City, State, Zip5, Zip4, addr } = this.state;
        return (
            <div className="formContent wrapper">
                <div class="row">
                    <form onSubmit={this.handleSubmit} class="form-horizontal">
                        <fieldset>
                            {/* Address form */}

                            <h2>Address</h2>

                            {/* full-name input */}
                            <div class="control-group">
                                <label class="control-label">Full Name</label>
                                <div class="controls">
                                    <input onChange={this.handleChange} value={Name} id="full-name" name="Name" type="textt" placeholder="full name"
                                        class="input-xlarge" />
                                    <p class="help-block"></p>
                                </div>
                            </div>
                            {/*<!-- address-line1 input-->*/}
                            <div class="control-group">
                                <label class="control-label">Address Line 1</label>
                                <div class="controls">
                                    <input onChange={this.handleChange} value={Address1} id="address-line1" name="Address1" type="textt" placeholder="address line 1"
                                        class="input-xlarge" />
                                    <p class="help-block">Street address, P.O. box, company name, c/o</p>
                                </div>
                            </div>
                            {/*<!-- address-line2 input-->*/}
                            <div class="control-group">
                                <label class="control-label">Address Line 2</label>
                                <div class="controls">
                                    <input onChange={this.handleChange} value={Address2} id="address-line2" name="Address2" type="textt" placeholder="address line 2"
                                        class="input-xlarge" />
                                    <p class="help-block">Apartment, suite , unit, building, floor, etc.</p>
                                </div>
                            </div>
                            {/*<!-- city input-->*/}
                            <div class="control-group">
                                <label class="control-label">City / Town</label>
                                <div class="controls">
                                    <input onChange={this.handleChange} value={City} id="city" name="City" type="textt" placeholder="city" class="input-xlarge" />
                                    <p class="help-block"></p>
                                </div>
                            </div>
                            {/*<!-- region input-->*/}
                            <div class="control-group">
                                <label class="control-label">State / Province / Region</label>
                                <div class="controls">
                                    <input onChange={this.handleChange} value={State} id="region" name="State" type="textt" placeholder="state / province / region"
                                        class="input-xlarge" />
                                    <p class="help-block"></p>
                                </div>
                            </div>
                            {/*<!-- postal-code input-->*/}
                            <div class="control-group">
                                <label class="control-label">Zip / Postal Code 5</label>
                                <div class="controls">
                                    <input onChange={this.handleChange} value={Zip5} id="postal-code" name="Zip5" type="textt" placeholder="zip or postal code"
                                        class="input-xlarge" />
                                    <p class="help-block"></p>
                                </div>
                                <label class="control-label">Zip / Postal Code 4</label>
                                <div class="controls">
                                    <input onChange={this.handleChange} value={Zip4} id="postal-code2" name="Zip4" type="textt" placeholder="zip or postal code"
                                        class="input-xlarge" />
                                    <p class="help-block"></p>
                                </div>
                            </div>

                        </fieldset>
                        <div id="formFooter">
                            <input type="submit" value="submit" class="fadeIn fourth" />
                        </div>
                    </form>

                </div>

            </div>


        );
    }
}
