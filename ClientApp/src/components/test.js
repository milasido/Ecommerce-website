import React, { Component } from 'react';

export class test extends Component {
    static displayName = test.name;

    constructor(props) {
        super(props);
        this.state = { test: [], done: false };
    }

    componentDidMount() {
        fetch('api/haha/validate')
            .then(res => res.json())
            .then(result => this.setState({ test: result.test }))
    }

    render() {
        if (!this.state.done) {
            return (
                <div>
                    
                </div>
            )
        }
        else {
            return (
                <div>
                    {this.state.test}
                </div>
            );
        }
    }
}
