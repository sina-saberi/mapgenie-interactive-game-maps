"use client"
import { useAppDispatch } from '@/src/hooks/useRedux';
import { IRegisterDto } from '@/src/services/nswag';
import { register as registerRedux, toggleModal } from '@/src/store/user';
import { Button, Modal, TextInput } from 'flowbite-react';
import Link from 'next/link';
import React from 'react'
import { useForm } from 'react-hook-form';
import { HiLockClosed, HiMail } from 'react-icons/hi';

const Register = () => {
    const dispatch = useAppDispatch();
    const { register, handleSubmit, formState: { errors } } = useForm<IRegisterDto>()

    const onFormSubmit = (e: IRegisterDto) =>
        dispatch(registerRedux(e))

    return (
        <React.Fragment>
            <Modal.Header>
                Register
            </Modal.Header>
            <Modal.Body>
                <form onSubmit={handleSubmit(onFormSubmit)}>
                    <div className='gap-5 grid'>
                        <div>
                            <TextInput
                                icon={HiMail} placeholder='User Name'
                                {...register("username",
                                    {
                                        required: {
                                            value: true,
                                            message: "username is required "
                                        }
                                    })
                                }
                            />
                            {errors.email && <span className="text-red-600 text-xs">{errors.email?.message}</span>}
                        </div>
                        <div>
                            <TextInput {...register("email", {
                                required: { value: true, message: "email is required " }, pattern: {
                                    value: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/,
                                    message: "Invalid email address"
                                }
                            })} icon={HiMail} placeholder='Email' />
                            {errors.email && <span className="text-red-600 text-xs">{errors.email?.message}</span>}
                        </div>

                        <div>
                            <TextInput {...register("password", { required: { value: true, message: "password is required " }, min: 8, max: 16 })} icon={HiLockClosed} placeholder='Passwor' />
                            {errors.password && <span className="text-red-600 text-xs">{errors.password?.message}</span>}
                        </div>
                    </div>
                    <div className='mt-10'>
                        <Button type="submit" fullSized>Login</Button>
                        <Link
                            onClick={(e) => {
                                e.preventDefault();
                                dispatch(toggleModal("login"));
                            }}
                            className="text-center text-cyan-500 text-sm mx-auto flex items-center justify-center pt-3" href={"#"}>
                            Login
                        </Link>
                    </div>
                </form>
            </Modal.Body>
        </React.Fragment>
    )
}

export default Register