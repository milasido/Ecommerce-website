import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';

export default function CartTotal({ handleClearCart }) {

    return (
        <div className="container">
            <div className="row">
                <div className="col-10 mt-2 ml-sm-5 ml-md-auto col-sm-8 text-capitalized text-right">
                    <Link to="/cart">
                        <button
                            className="btn btn-outline-danger text-uppercase mb-3 px-5"
                            type="button"
                            onClick={handleClearCart}
                        >
                            Clear Cart
                    </button>
                    </Link>
                    <h5>
                        <span className="text-title">Subtotal: </span>
                        <strong>$</strong>
                    </h5>
                    <h5>
                        <span className="text-title">Tax: </span>
                        <strong>$</strong>
                    </h5>
                    <h5>
                        <span className="text-title">Total: </span>
                        <strong>$</strong>
                    </h5>

                    <Link to="/checkout">
                        <button
                            className="btn btn-outline-danger text-uppercase mb-3 px-5"
                            type="button"
                            
                        >
                            Begin to checkout
                        </button>
                    </Link>
                </div>
            </div>
        </div>
    );
}