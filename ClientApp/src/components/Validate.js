import React, { Component } from 'react';
import './Validate.css';

export class Validate extends Component {
    static displayName = Validate.name;

    //api/validate/validate
/*
    constructor(props) {
        super(props);
        this.state = {
            Name: '',
            Address1: '',
            Address2: '',
            City = '',
            State = '',
            Zip5='',
            Zip4=''
        }
    }
    handleSubmit = (event) => {
        this.setState({
            Name: event.target.value,
            Address1: event.target.value,
            Address2: event.target.value,
            City: event.target.value,
            State: event.target.value,
            Zip5: event.target.value,
            Zip4: event.target.value,
        })
    }
*/

    render() {
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
                                    <input id="full-name" name="full-name" type="textt" placeholder="full name"
                                        class="input-xlarge" />
                                    <p class="help-block"></p>
                                </div>
                            </div>
                            {/*<!-- address-line1 input-->*/}
                            <div class="control-group">
                                <label class="control-label">Address Line 1</label>
                                <div class="controls">
                                    <input id="address-line1" name="address-line1" type="textt" placeholder="address line 1"
                                        class="input-xlarge" />
                                    <p class="help-block">Street address, P.O. box, company name, c/o</p>
                                </div>
                            </div>
                            {/*<!-- address-line2 input-->*/}
                            <div class="control-group">
                                <label class="control-label">Address Line 2</label>
                                <div class="controls">
                                    <input id="address-line2" name="address-line2" type="textt" placeholder="address line 2"
                                        class="input-xlarge" />
                                    <p class="help-block">Apartment, suite , unit, building, floor, etc.</p>
                                </div>
                            </div>
                            {/*<!-- city input-->*/}
                            <div class="control-group">
                                <label class="control-label">City / Town</label>
                                <div class="controls">
                                    <input id="city" name="city" type="textt" placeholder="city" class="input-xlarge" />
                                    <p class="help-block"></p>
                                </div>
                            </div>
                            {/*<!-- region input-->*/}
                            <div class="control-group">
                                <label class="control-label">State / Province / Region</label>
                                <div class="controls">
                                    <input id="region" name="region" type="textt" placeholder="state / province / region"
                                        class="input-xlarge" />
                                    <p class="help-block"></p>
                                </div>
                            </div>
                            {/*<!-- postal-code input-->*/}
                            <div class="control-group">
                                <label class="control-label">Zip / Postal Code</label>
                                <div class="controls">
                                    <input id="postal-code" name="postal-code" type="textt" placeholder="zip or postal code"
                                        class="input-xlarge" />
                                    <p class="help-block"></p>
                                </div>
                            </div>
                           
                        </fieldset>
                    </form>
                </div>
                <div id="formFooter">
                    <input type="submit" value="submit" class="fadeIn fourth" />
                </div>
            </div>
        );
    }
}
